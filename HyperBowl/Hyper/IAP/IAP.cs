#if HYPER_IAP

using UnityEngine;
using UnityEngine.Purchasing;

namespace Hyper {

public class IAP : MonoBehaviour, IStoreListener {

    private IStoreController controller;
    private IExtensionProvider extensions;

    void Start() {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("hyper_pro", ProductType.NonConsumable, new IDs
        {
            {"com.technicat.hyperbowl.pro", GooglePlay.Name},
            {"com.technicat.hyperbowl", MacAppStore.Name}
        });

        UnityPurchasing.Initialize (this, builder);
    }

    public void BuyPro() {
        BuyProductID("com.technicat.hyperbowl.pro");
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = controller.products.WithID(productId);

            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product:" + product.definition.id.ToString()));
                controller.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

     private bool IsInitialized()
    {
        return this.controller != null && this.extensions != null;
    }

    /// <summary>
    /// Called when Unity IAP is ready to make purchases.
    /// </summary>
    public void OnInitialized (IStoreController controller, IExtensionProvider extensions)
    {
        this.controller = controller;
        this.extensions = extensions;
    }

    /// <summary>
    /// Called when Unity IAP encounters an unrecoverable initialization error.
    ///
    /// Note that this will not be called if Internet is unavailable; Unity IAP
    /// will attempt initialization until it becomes available.
    /// </summary>
    public void OnInitializeFailed (InitializationFailureReason error)
    {
    }

    /// <summary>
    /// Called when a purchase completes.
    ///
    /// May be called at any time after OnInitialized().
    /// </summary>
    public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs e)
    {
        return PurchaseProcessingResult.Complete;
    }

    /// <summary>
    /// Called when a purchase fails.
    /// </summary>
    public void OnPurchaseFailed (Product i, PurchaseFailureReason p)
    {
    }
}
}
#endif