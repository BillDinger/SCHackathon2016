namespace Sitecore.Feature.Blog.CMS.Validation
{
    using Sitecore.Data.Validators;
    public class CategoriesNotRecursiveValidator : StandardValidator
    {
        protected override ValidatorResult Evaluate()
        {

            return ValidatorResult.Unknown;
        }

        protected override ValidatorResult GetMaxValidatorResult()
        {
            return ValidatorResult.Error;
        }

        public override string Name { get { return "Categories Not Recursive"; }
    }
}