using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Saltarelle.Utils
{
	public static class StaticReflection
	{
		public static string GetMemberName<T, TMemberType>(
			// ReSharper disable once UnusedParameter.Global
			this T instance,
			Expression<Func<T, TMemberType>> expression)
		{
			return GetMemberName(expression);
		}

		public static string GetMemberName<T, TMemberType>(
			this Expression<Func<T, TMemberType>> expression)
		{
			if (expression == null)
			{
				throw new ArgumentException(
					"The expression cannot be null.");
			}

			return GetMemberName(expression.Body);
		}

		public static string GetMemberName<T>(
			// ReSharper disable once UnusedParameter.Global
			this T instance,
			Expression<Action<T>> expression)
		{
			return GetMemberName(expression);
		}

		public static string GetMemberName<T>(
			Expression<Action<T>> expression)
		{
			if (expression == null)
			{
				throw new ArgumentException(
					"The expression cannot be null.");
			}

			return GetMemberName(expression.Body);
		}

		public static string GetMemberName<T>(this Expression<Func<T>> staticMember)
		{
			return GetMemberName((Expression)staticMember);
		}

		private static string GetMemberName(
			Expression expression)
		{
			if (expression == null)
			{
				throw new ArgumentException(
					"The expression cannot be null.");
			}

			var expression1 = expression as MemberExpression;
			if (expression1 != null)
			{
				// Reference type property or field
				var memberExpression =
					expression1;
				return memberExpression.Member.Name;
			}

			var callExpression = expression as MethodCallExpression;
			if (callExpression != null)
			{
				// Reference type method
				var methodCallExpression =
					callExpression;
				return methodCallExpression.Method.Name;
			}

			var unaryExpression1 = expression as UnaryExpression;
			if (unaryExpression1 != null)
			{
				// Property, field of method returning value type
				var unaryExpression = unaryExpression1;
				return GetMemberName(unaryExpression);
			}

			var lambdaExpression1 = expression as LambdaExpression;
			if (lambdaExpression1 != null)
			{
				// Property, field of method returning value type
				var lambdaExpression = lambdaExpression1;
				return GetMemberName(lambdaExpression.Body);
			}


			throw new ArgumentException("Invalid expression");
		}

		private static string GetMemberName(
			UnaryExpression unaryExpression)
		{
			var operand = unaryExpression.Operand as MethodCallExpression;
			if (operand != null)
			{
				var methodExpression =
					operand;
				return methodExpression.Method.Name;
			}

			return ((MemberExpression)unaryExpression.Operand)
				.Member.Name;
		}

		/// <summary>
		/// Hooks into the setter of a property.
		/// If the referenced member is a field, the method converts the field
		/// into property.
		/// </summary>
		/// <typeparam name="TObjectType"></typeparam>
		/// <typeparam name="TMemberType"></typeparam>
		/// <param name="obj"></param>
		/// <param name="propertySelector">
		/// selects the property for typesafe declaration of the property name
		/// </param>
		/// <param name="onSetProperty">
		/// the hook-handler
		/// void OnPropertySet({TMemberType} newValue);
		/// </param>
		public static void HookSetterOfProperty<TObjectType, TMemberType>(this TObjectType obj, Expression<Func<TObjectType, TMemberType>> propertySelector, Action<TMemberType> onSetProperty)
		{
			var propertyName = propertySelector.GetMemberName();
			var firstChar = propertyName[0].ToString().ToLower();
			if (propertyName.Length > 1)
				propertyName = firstChar + propertyName.Substring(1);
			else
				propertyName = firstChar;

			HookSetterOfProperty(obj, propertyName, onSetProperty);
		}

		/// <summary>
		/// Hooks into the setter of a property.
		/// If the referenced member is a field, the method converts the field
		/// into property.
		/// </summary>
		/// <typeparam name="TObjectType"></typeparam>
		/// <typeparam name="TMemberType"></typeparam>
		/// <param name="obj"></param>
		/// <param name="propertyName"></param>
		/// <param name="onSetProperty">
		/// the hook-handler
		/// void OnPropertySet({TMemberType} newValue);
		/// </param>
		[InlineCode(
			@"(function() {{
				var oldProperty = {obj}[{propertyName}];
				Object.defineProperty({obj}, {propertyName}, {{
					get: function() {{
						return oldProperty;
					}},
					set: function(value) {{
						oldProperty = value;
						{onSetProperty}(value);
					}}
			    }});
			}})();")]
		public static void HookSetterOfProperty<TObjectType, TMemberType>(this TObjectType obj, string propertyName, Action<TMemberType> onSetProperty)
		{
		}
	}
}
