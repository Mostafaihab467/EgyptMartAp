namespace EgyptMart.Services.Auth.Classes
{
    public static class HTMLTemplate
    {
        public static string VerifyCodeHTML(string email, string code)
        {
            return $@"
            <!DOCTYPE html>
            <html lang='en'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <title>Password Reset Verification</title>
                <style>
                    body {{

                        font-family: Arial, sans-serif;
                        color: #333;
                        background-color: #f4f4f4;
                        margin: 0;
                        padding:  10px 0 0 0;
                    }}
                    .email-container {{
                        width: 100%;
                        max-width: 600px;
                        margin: 0 auto;
                        background-color: #fff;
                        padding: 20px;
                        border-radius: 8px;
                        box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1);
                    }}
                    .email-header {{
                        background-color: #ce1126;
                        color: white;
                        padding: 15px;
                        text-align: center;
                        border-radius: 8px 8px 0 0;
                    }}
                    .email-body {{
                        padding: 20px;
                        font-size: 16px;
                    }}
                    .verification-code {{
                        font-size: 24px;
                        font-weight: bold;
                        color: #ce1126;
                        margin: 20px 0;
                    }}
                    .footer {{
                        margin-top: 20px;
                        font-size: 12px;
                        text-align: center;
                        color: #777;
                    }}
                    .footer a {{
                        color: #ce1126;
                        text-decoration: none;
                    }}
                </style>
            </head>
            <body>
                <div class='email-container'>
                    <!-- Email Header -->
                    <div class='email-header'>
                        <h2>Password Reset</h2>
                    </div>

                    <!-- Email Body -->
                    <div class='email-body'>
                        <p>Hello {email},</p>
                        <p>We received a request to reset your password. Please use the following verification code to proceed with resetting your password:</p>

                        <!-- Verification Code -->
                        <div class='verification-code'>
                            {code}
                        </div>

                        <p>If you did not request a password reset, please ignore this email.</p>
                        <p>This code will expire in 45 minutes for security reasons.</p>
                    </div>

                    <!-- Email Footer -->
                    <div class='footer'>
                        <p>If you have any questions, feel free to <a href='mailto:support@example.com'>contact support</a>.</p>
                        <p>&copy; 2025 EdgeCome. All rights reserved.</p>
                    </div>
                </div>
            </body>
            </html>";
        }

    }
}
