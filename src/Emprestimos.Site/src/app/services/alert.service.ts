import { Injectable } from "@angular/core";
import { ToastrService } from "ngx-toastr";

@Injectable({
    providedIn: 'root'
})
export class AlertService {
    constructor(private toastr: ToastrService) { }

    sucesso(texto: string) {
        this.toastr.success(texto, 'Sucesso!');
    }

    aviso(texto: string) {
        this.toastr.warning(texto, "Aviso!");
    }

    erro(texto: string) {
        this.toastr.error(texto, "Erro!");
    }

    info(texto: string) {
        this.toastr.info(texto, "Informação");
    }
}