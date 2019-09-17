import * as $ from "jquery";
import axios, { AxiosPromise, AxiosResponse } from "axios";

module Auth {
    const ui = {
        login: $(".jLogin"),
        password: $(".jPassword"),
        submitBtn: $(".jSubmitBtn"),
        submitAdminBtn: $(".jSubmitAdminBtn"),
        submitBtn2: $(".jSubmitv2"),
        userId: $(".jUserId"),
    }

    function bind() {
        ui.submitBtn.click(() => {
            //asd
            var data = {
                login: ui.login.val(),
                password: ui.password.val()
            }


            axios.post("/auth/login", data).then(res => {
                var data = res.data;
                var userId = (data as any).userId;
                var success = (data as any).ok;

                if (success) {
                    location.href = "/categories/index?userId=" + userId;
                }
            });
        });

        ui.submitAdminBtn.click(() => {
            //asd
            var data = {
                login: ui.login.val(),
                password: ui.password.val()
            }


            axios.post("/auth/loginAdmin", data).then(res => {
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