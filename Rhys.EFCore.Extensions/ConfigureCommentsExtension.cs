using System;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rhys.EFCore.Extensions.Core;

namespace Rhys.EFCore.Extensions
{
    public static class ConfigureCommentsExtension
    {

        /// <summary>
        /// 配置实体类对应数据表的注释
        /// </summary>
        /// <param name="entityTypeBuilder"></param>
        public static void TryConfigureEntityComment<T>(this EntityTypeBuilder<T> entityTypeBuilder) where T : class
        {
            try
            {
                var dic = XmlDocumentHelper.GetPropCommentByClassType<T>();

                //Config Class Name Comment to Database Table Name Comment
                entityTypeBuilder.ToTable(c => c.HasComment(dic[typeof(T).FullName ?? "className"]));

                //Config Property Comment to Database Column Comment
                foreach (var property in typeof(T).GetProperties())
                {
                    var propName = property.Name;
                    var comment = dic[propName];
                    var lambda = LambdaExpressionGenerator.CreateLambdaExpression<T>(property);
                    EntityTypeBuilderConfig(property, lambda, entityTypeBuilder, comment);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        static void EntityTypeBuilderConfig<T>(PropertyInfo property, LambdaExpression lambda,
            EntityTypeBuilder<T> b, string? comment) where T : class
        {

            try
            {
                if (typeof(Guid) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, Guid>>)lambda).HasComment(comment);
                }
                else if (typeof(Guid?) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, Guid?>>)lambda).HasComment(comment);
                }
                else if (typeof(string) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, string>>)lambda).HasComment(comment);
                }
                else if (typeof(int) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, int>>)lambda).HasComment(comment);
                }
                else if (typeof(bool) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, bool>>)lambda).HasComment(comment);
                }
                else if (typeof(DateTime?) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, DateTime?>>)lambda).HasComment(comment);
                }
                else if (typeof(DateTime) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, DateTime>>)lambda).HasComment(comment);
                }
                else if (typeof(Enum) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, Enum>>)lambda).HasComment(comment);
                }
                else if (typeof(long) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, long>>)lambda).HasComment(comment);
                }
                else if (typeof(long?) == property.PropertyType)
                {
                    b.Property((Expression<Func<T, long?>>)lambda).HasComment(comment);
                }
                // config  your customer type here
                else
                {
                    var currentBackgroundColor = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(@$"{property.PropertyType}  the property data type is not matched, you need to add a type configuration  ");
                    Console.BackgroundColor = currentBackgroundColor;
                }
            }
            catch (Exception e)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine($"Failed to set comment field:{e.Message}");
            }
        }

    }
}
