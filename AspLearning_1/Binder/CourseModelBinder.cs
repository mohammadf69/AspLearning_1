using AspLearning_1.Entites;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AspLearning_1.Binder;

public class CourseModelBinder:IModelBinder
{
    public  Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var course = new Course();
        if (bindingContext.ValueProvider.GetValue("Title").Length>0)
        {
            course.Titele = bindingContext.ValueProvider.GetValue("Title").FirstValue!;
        }

        if (bindingContext.ValueProvider.GetValue("Level").Length>0)
        {
            course.Level = int.Parse(bindingContext.ValueProvider.GetValue("Level").FirstValue!);
        }
        bindingContext.Result = ModelBindingResult.Success(course);
        return Task.CompletedTask;
    }
}