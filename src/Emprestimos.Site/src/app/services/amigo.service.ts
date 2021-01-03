import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EMPTY } from "rxjs";
import { AmigoModel } from "../models/amigo.model";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: 'root'
})
export class AmigoService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    inserir(amigo: AmigoModel) {
        return this.http.post(this.baseUrl + 'Amigo', amigo);
    }

    atualizar(id: number, amigo: AmigoModel) {
        return this.http.put(this.baseUrl + `Amigo/${id}`, amigo);
    }

    obter() {
        return this.http.get<AmigoModel[]>(this.baseUrl + 'Amigo')
    }

    obterPorId(id: number) {
        return this.http.get<AmigoModel>(this.baseUrl + `Amigo/${id}`)
    }

    remover(id: number) {
        return this.http.delete<AmigoModel[]>(this.baseUrl + `Amigo/${id}`)
    }

    devolverTodosJogos(id: number) {
        return this.http.patch<AmigoModel>(this.baseUrl + `Amigo/${id}/devolver-todos-jogos`, EMPTY)
    }
}