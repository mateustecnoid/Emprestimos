import { HttpClient } from "@angular/common/http";
import { EventEmitter, Injectable } from "@angular/core";
import { AutenticacaoModel } from "../models/autenticacao.model";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: 'root'
})
export class AutenticacaoService extends BaseService {

    usuarioLogadoEmmiter = new EventEmitter<boolean>();

    constructor(private http: HttpClient) {
        super();
    }

    Autenticar(autenticacao: AutenticacaoModel) {
        return this.http.post<AutenticacaoModel>(this.baseUrl + 'Autenticacao', autenticacao);
    }

    UsuarioAutenticado(): string {
        let usuario = localStorage.getItem('usuario');

        return usuario;
    }

    Sair() {
        localStorage.removeItem('usuario');
        localStorage.removeItem('token');
        localStorage.removeItem('usuarioId');
        this.usuarioLogadoEmmiter.emit(false);
    }
}