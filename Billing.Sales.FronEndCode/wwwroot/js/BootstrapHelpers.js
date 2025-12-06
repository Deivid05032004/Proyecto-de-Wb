namespace Billing.Sales.FrontEndCode.wwwroot.js
{
    public class BootstrapHelpers
    {
        window.bootstrapModal = {
            show: function (selector) {
                const modal = new bootstrap.Modal(document.querySelector(selector));
                modal.show();
            }
        };
    }
}
