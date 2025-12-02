using AspLearning_1.Entites;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AspLearning_1.Binder;

public class CourseBinderProvider:IModelBinderProvider
{
    public IModelBinder? GetBinder(ModelBinderProviderContext context)
    {
        if (context.Metadata.ModelType==(typeof(Course)))
        {
            return new BinderTypeModelBinder(typeof(CourseModelBinder));
        }
        return null;
    }
}