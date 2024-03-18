using System;

namespace Test.Thunders.Application.Base.Error;

public class UnexpectedError : ErrorDetail
{
    private const string ERROR_CODE = "STANDARD-ISE-500";
    private const string ERROR_MESSAGE = "An unexpected error happened. If the error persists, please contact us: atendimentobaas@bancoarbi.com.br";

    public string ExceptionMessage { get; set; }
    public string StackTrace { get; set; }

    public UnexpectedError(Exception exception, bool isDevelopment = false) : base(ERROR_CODE, ERROR_MESSAGE)
    {
        ExceptionMessage = isDevelopment ? exception.Message : null;
        StackTrace = isDevelopment ? exception.StackTrace : null;
    }
}
