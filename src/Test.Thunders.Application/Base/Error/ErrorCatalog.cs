using System.Diagnostics.CodeAnalysis;

namespace Test.Thunders.Application.Base.Error;

[ExcludeFromCodeCoverage]
public static class ErrorCatalog
{
    [ExcludeFromCodeCoverage]
    public static class TestError
    {

        #region Base

        public static ErrorCatalogEntry BaseInvalidRequest =>
            ("01", "Invalid request");

        #endregion Base


        #region GetById

        public static ErrorCatalogEntry GetByIdNotFound =>
            ("01", "[id] not found");

        #endregion

        #region Craete

        public static ErrorCatalogEntry CreateOrUpdateDescriptionIsNullOrEmpty =>
            ("01", "[name] parameter cant be null or empty");
        #endregion

        #region Update
        public static ErrorCatalogEntry UpdateStatusIsNullOrEmpty =>
            ("02", "[status] parameter cant be null or empty");
        #endregion

        #region Delete
        public static ErrorCatalogEntry DeleteIdIsNullOrEmpty =>
            ("01", "[id] parameter cant be null or empty");
        #endregion
    }
}
