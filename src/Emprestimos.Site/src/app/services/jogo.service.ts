import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EnumModel } from "../models/enum.model";
import { JogoModel } from "../models/jogo.model";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: 'root'
})
export class JogoService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    inserir(jogo: JogoModel) {
        return this.http.post(this.baseUrl + 'Jogo', jogo);
    }

    atualizar(id: number, jogo: JogoModel) {
        return this.http.put(this.baseUrl + `Jogo/${id}`, jogo);
    }

    obter() {
        return this.http.get<JogoModel[]>(this.baseUrl + 'Jogo')
    }

    obterPorId(id: number) {
        return this.http.get<JogoModel>(this.baseUrl + `Jogo/${id}`)
    }

    remover(id: number) {
        return this.http.delete<JogoModel[]>(this.baseUrl + `Jogo/${id}`)
    }

    obterSituacoes(){
        return this.http.get<EnumModel[]>(this.baseUrl + 'Jogo/situacoes')
    }

    obterGeneros(){
        return this.http.get<EnumModel[]>(this.baseUrl + 'Jogo/generos')
    }
}