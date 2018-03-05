using System;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PizzaShoppe.WebUI.Models
{
    public static class ExtensionMethod_HiddenForCollection
    {
        /// <summary>
        /// Returns an HTML hidden input element for each item in the object's property (collection) that is represented by the specified expression.
        /// Shamelessly stolen from: https://stackoverflow.com/questions/9385286/html-hiddenfor-does-not-work-on-lists-in-asp-net-mvc
        /// </summary>
        public static IHtmlString HiddenForCollection<TModel, TProperty>(this HtmlHelper<TModel> html, Expression<Func<TModel, TProperty>> expression) where TProperty : ICollection
        {
            var model = html.ViewData.Model;
            var property = model != null
                        ? expression.Compile().Invoke(model)
                        : default(TProperty);

            var result = new StringBuilder();
            if (property != null && property.Count > 0)
            {
                for (int i = 0; i < property.Count; i++)
                {
                    var modelExp = expression.Parameters.First();
                    var propertyExp = expression.Body;
                    var itemExp = Expression.ArrayIndex(propertyExp, Expression.Constant(i));

                    var itemExpression = Expression.Lambda<Func<TModel, object>>(itemExp, modelExp);

                    result.AppendLine(html.HiddenFor(itemExpression).ToString());
                }
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}