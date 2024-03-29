import { Injectable } from '@angular/core';

declare let alertify;
@Injectable({
    providedIn: 'root'
})
export class AlertifyService {
    constructor() { }
    confirm(message: string, okCallback: () => any) {
        alertify.confirm(message, function (e) {
            if (e) {
                okCallback();
            } else {

            }
        });
    }

    success(message: string) {
        alertify.success(message);
    }

    error(message: string) {
        console.log('error');
        alertify.error(message);
    }

    warning(message: string) {
        alertify.warning(message);
    }

    message(message: string) {
        alertify.message(message);
    }
}
