namespace SchoolSystemTask.services;
using PayPal.Api;

public class PayPalService(IConfiguration config)
{
    private readonly string clientId = config["PayPal:ClientId"];
    private readonly string clientSecret = config["PayPal:ClientSecret"];

    private APIContext GetAPIContext()
    {
        var oauthToken = new OAuthTokenCredential(clientId, clientSecret).GetAccessToken();
        return new APIContext(oauthToken);
    }

    public Payment CreatePayment(string redirectUrl, decimal total, string? message, int userId)
    {
        var apiContext = GetAPIContext();

        // Define payment details
        var payment = new Payment
        {
            intent = "sale",
            payer = new Payer { payment_method = "paypal" },
            transactions = new List<Transaction>
                {
                    new Transaction
                    {
                        amount = new Amount
                        {
                            currency = "USD",
                            total = $"{total}" // amount to charge
                        },
                        description = message?? "Product description"
                    }
                },
            redirect_urls = new RedirectUrls
            {
                cancel_url = $"{redirectUrl}/cancel",
                return_url = $"{redirectUrl}/success?userId={userId}"
            }
        };

        // Create payment using PayPal API
        return payment.Create(apiContext);
    }

    public Payment ExecutePayment(string paymentId, string payerId)
    {
        var apiContext = GetAPIContext();
        var paymentExecution = new PaymentExecution { payer_id = payerId };
        var payment = new Payment { id = paymentId };

        // Execute payment
        return payment.Execute(apiContext, paymentExecution);
    }
}


