import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { EMPTY } from "rxjs";
import { EmprestimoModel } from "../models/emprestimo.model";
import { BaseService } from "./base.service";

@Injectable({
    providedIn: 'root'
})
export class EmprestimoService extends BaseService {
    constructor(private http: HttpClient) {
        super();
    }

    inserir(emprestimo: EmprestimoModel) {
        return this.http.post(this.baseUrl + 'Emprestimo', emprestimo);
    }

    atualizar(id: number, emprestimo: EmprestimoModel) {
        return this.http.put(this.baseUrl + `Emprestimo/${id}`, emprestimo);
    }

    obter() {
        return this.http.get<EmprestimoModel[]>(this.baseUrl + 'Emprestimo')
    }

    obterPorId(id: number) {
        return this.http.get<EmprestimoModel>(this.baseUrl + `Emprestimo/${id}`)
    }

    remover(id: number) {
        return this.http.delete<EmprestimoModel[]>(this.baseUrl + `Emprestimo/${id}`)
    }

    devolver(id: number) {
        return this.http.patch<EmprestimoModel>(this.baseUrl + `Emprestimo/${id}/devolver`, EMPTY)
    }
}