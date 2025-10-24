using System;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace DataGridView
{
    public static class BindingExtensions
    {
        public static void AddBinding<TControl, TSource>(
            this TControl control,
            Expression<Func<TControl, object>> controlProperty,
            TSource dataSource,
            Expression<Func<TSource, object>> dataMember,
            ErrorProvider errorProvider = null,
            Action validationAction = null)
            where TControl : Control
        {
            var controlPropertyName = GetPropertyName(controlProperty);
            var dataMemberName = GetPropertyName(dataMember);

            var binding = new Binding(controlPropertyName, dataSource, dataMemberName, true, DataSourceUpdateMode.OnPropertyChanged);

            if (errorProvider != null && validationAction != null)
            {
                binding.Format += (s, e) => validationAction();
                binding.Parse += (s, e) => validationAction();

                control.Validated += (s, e) => validationAction();
                control.TextChanged += (s, e) => validationAction();
            }

            control.DataBindings.Add(binding);
        }

        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            var memberExpression = expression.Body as MemberExpression;
            if (memberExpression == null)
            {
                var unaryExpression = expression.Body as UnaryExpression;
                if (unaryExpression != null)
                {
                    memberExpression = unaryExpression.Operand as MemberExpression;
                }
            }

            return memberExpression?.Member.Name ?? throw new ArgumentException("Invalid expression");
        }
    }
}