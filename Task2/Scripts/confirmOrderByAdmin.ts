import * as $ from "jquery";
import axios, { AxiosPromise, AxiosResponse } from "axios";

module ConfirmOrderByAdmin {
    const ui = {
        confirmOrderBtn: $(".jConfirmOrder"),
        orderId: $(".jOrderId"),
    }

    function bind() {
        ui.confirmOrderBtn.click(() => {
            //asd
            var data = {
                orderId: ui.orderId.val()
            }

            
            axios.post("/Orders/ConfirmOrderByAdmin", data).then(res => {
                var data = res.data;
                var success = (data as any).ok;

                if (success) {
                    location.href = "/admin/orders/forAdmin";
                }
            });

        });
    }

    bind();

}