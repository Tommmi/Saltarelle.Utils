# Saltarelle.Utils
Shared library for all Tommmi projects which uses Saltarelle

## History
see [history](documentation/history.md)

## Contents

### Classes
| Class | Description   |
| ----- | ----------    |
| jQueryEventMouseWheel | MouseWheelEvent <br>Requirements:<br>- jquery.js<br>- jquery.mousewheel.js |
|  |  |
|  |  |



### Extensions
| Extended Type | Extension Method | Description   |
| ------------- | -------------    | ------------- |
| DateTime | AddDaysSafe(int days) | Adds passed numer of days. In case of daylight saving the resulting date time has the same time as before. |
| T | GetMemberName<T, TMemberType>(Func<T, TMemberType> getPropertyName) | gets name of selected property |
| Expression&lt;Func&lt;T, TMemberType&gt;&gt; | GetMemberName() | gets name of selected property | 
| TObjectType | HookSetterOfProperty(Func&lt;TObjectType, TMemberType&gt; propertySelector, Action&lt;TMemberType&gt; onSetProperty) | Hooks into the setter of a property. If the referenced member is a field, the method converts the field into property. |
|  |  |  |

