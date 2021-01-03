import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { UsuarioModel } from "../models/usuario.model";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: 'root'
})
export class UsuarioService extends BaseService{
    constructor(private http: HttpClient) {
        super();
    }

    Inserir(usuario: UsuarioModel) {
        return this.http.post(this.baseUrl + 'Usuario', usuario);
    }

    Atualizar(id: number, usuario: UsuarioModel) {
        return this.http.post(this.baseUrl + `Usuario/${id}`, usuario);
    }

    Obter() {
        return this.http.get<UsuarioModel[]>(this.baseUrl + 'Usuario')
    }

    ObterPorId(id: number) {
        return this.http.get<UsuarioModel>(this.baseUrl + `Usuario/${id}`)
    }

    Remover(id: number) {
        return this.http.delete<UsuarioModel[]>(this.baseUrl + `Usuario/${id}`)
    }
}