var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        });
        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/Payment";
        });
        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartListPro = [];
            $.each(listProduct, function (i, item) {
                cartListPro.push({
                    productQuantity: $(item).val(),
                    Product: {
                        proId: $(item).data('id')
                    }
                });
            });

            

            $.ajax({
                url: '/Cart/Update',
                data: { cartModelPro: JSON.stringify(cartListPro) },
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })


            //var listPack = $('.txtQuantityPack');
            //var cartListPack = [];
            //$.each(listPack, function (i, item) {
            //    cartListPack.push({
            //        packQuantity: $(item).val(),
            //        Pack: {
            //            packId: $(item).data('id')
            //        }
            //    });
            //});
            //$.ajax({
            //    url: '/Cart/UpdatePack',
            //    data: { cartModelPack: JSON.stringify(cartListPack) },
            //    dataType: 'json',
            //    type: 'POST',
            //    success: function (res) {
            //        if (res.status == true) {
            //            window.location.href = "/Cart";
            //        }
            //    }
            //})
            
        });

        

        
        $('#btnDeleteAll').off('click').on('click', function () {


            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { proId: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })

            $.ajax({
                data: { packId: $(this).data('id') },
                url: '/Cart/DeletePack',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/Cart";
                    }
                }
            })

        });
    }
}
cart.init();