import * as $ from "jquery";
import axios, { AxiosPromise, AxiosResponse } from "axios";

module CreateOrder {
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

            
            axios.post("/Orders/ConfirmOrderByUser", data).then(res => {
                var data = res.data;
                var userId = (data as any).userId;
                var success = (data as any).ok;

                if (success) {
                    location.href = "/cart/index?userId=" + userId;
                }
            });

        });
    }

    bind();

}