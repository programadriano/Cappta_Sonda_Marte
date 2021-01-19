import { Injectable } from '@angular/core';
import swal from 'sweetalert2';

@Injectable()
export class AlertService {

    success(title: string, textMessage: string, textbutton: string) {
        return swal.fire({
            icon: 'success',
            title: title,
            text: textMessage
        })
    }

    error(title: string, textMessage: string, textbutton: string) {
        return swal.fire({
            icon: 'error',
            title: title,
            text: textMessage
        })
    }

    warning(title: string, textMessage: string, textbutton: string) {
        return swal.fire({
            icon: 'warning',
            title: title,
            text: textMessage
        })
    }

    info(title: string, textMessage: string, textbutton: string) {
        return swal.fire({
            icon: 'info',
            title: title,
            text: textMessage
        })
    }
}