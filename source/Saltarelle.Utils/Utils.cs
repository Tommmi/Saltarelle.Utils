using System;
using System.Collections;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using AngularJS;
using jQueryApi;

namespace Saltarelle.Utils
{
	public static class Utils
	{
		/// <summary>
		/// Makes a flat copy of all members from class TDestType to object src.
		/// So the JavaScript object src will know thows new members now.
		/// Casts src to type TDestType, so all changes to the returned value will have affects to 
		/// the passed object src.
		/// "Enhance" will also copy prototype members to src.
		/// </summary>
		/// <typeparam name="TDestType">
		/// Must be directly derived from TSrcType.
		/// Must have a default constructor
		/// </typeparam>
		/// <typeparam name="TSrcType"></typeparam>
		/// <param name="src">
		/// The object which will get new members by this method call
		/// </param>
		/// <returns>the parameter "src" enhanced by new members</returns>
		public static TDestType Enhance<TDestType, TSrcType>(TSrcType src)
			where TDestType : class, TSrcType, new()
			where TSrcType : class
		{
			return Enhance(src, () => new TDestType());
		}

		/// <summary>
		/// Makes a flat copy of all members from class TDestType to object src.
		/// So the JavaScript object src will know thows new members now.
		/// Casts src to type TDestType, so all changes to the returned value will have affects to 
		/// the passed object src.
		/// "Enhance" will also copy prototype members to src.
		/// </summary>
		/// <typeparam name="TDestType">
		/// Must be directly derived from TSrcType.
		/// </typeparam>
		/// <typeparam name="TSrcType"></typeparam>
		/// <param name="src">
		/// The object which will get new members by this method call
		/// </param>
		/// <param name="createDefault">
		/// creator delegate for TDestType
		/// </param>
		/// <returns>src enhanced by new members</returns>
		public static TDestType Enhance<TDestType, TSrcType>(TSrcType src, Func<TDestType> createDefault)
			where TDestType : class, TSrcType
			where TSrcType : class
		{
			jQuery.ExtendObject(src, createDefault());
			return UnsafeSafeCast<TDestType>(src);
		}

		/// <summary>
		/// Casts an object to the given type without any validation
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns></returns>
		[InlineCode("{obj}")]
		public static T UnsafeSafeCast<T>(object obj)
			where T : class
		{
			return null;
		}

		/// <summary>
		/// Angular Feature !
		/// Creates a hook on a scope property by using the Angular method watch(..)
		/// </summary>
		/// <typeparam name="TScopeType"></typeparam>
		/// <typeparam name="TPropertyType"></typeparam>
		/// <param name="scope"></param>
		/// <param name="propertySelector"></param>
		/// <param name="handler">
		/// void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue)
		/// </param>
		public static void WatchProperty<TScopeType, TPropertyType>(
			this TScopeType scope,
			Expression<Func<TScopeType, TPropertyType>> propertySelector,
			WatchListener<TPropertyType> handler)
			where TScopeType : Scope
		{
			var propertyName = scope.GetMemberName(propertySelector);
			scope.Watch(propertyName, handler);
		}

		/// <summary>
		/// Angular Feature !
		/// Creates a hook on a scope collection property by using the Angular method watch(..)
		/// </summary>
		/// <typeparam name="TScopeType"></typeparam>
		/// <typeparam name="TPropertyType"></typeparam>
		/// <param name="scope"></param>
		/// <param name="propertySelector"></param>
		/// <param name="handler">
		/// void OnPropertyChanged(TPropertyType newValue, TPropertyType oldValue)
		/// </param>
		public static void WatchPropertyCollection<TScopeType, TPropertyType>(
			this TScopeType scope,
			Expression<Func<TScopeType, TPropertyType>> propertySelector,
			WatchListener<TPropertyType> handler)
			where TScopeType : Scope
			where TPropertyType: IEnumerable
		{
			var propertyName = scope.GetMemberName(propertySelector);
			scope.WatchCollection(propertyName, handler);
		}

		/// <summary>
		/// jQuery.Select("#myModalDlg").ModalShow();
		/// is like $("#myModalDlg").modal("show");
		/// </summary>
		/// <param name="node"></param>
		[InlineCode("{node}.modal('show')")]
		public static void ModalShow(this jQueryObject node)
		{
		}
	}
}
