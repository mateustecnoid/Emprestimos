import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AutenticacaoModel } from '../../../models/autenticacao.model';
import { UsuarioModel } from '../../../models/usuario.model';
import { AlertService } from '../../../services/alert.service';
import { AutenticacaoService } from '../../../services/autenticacao.service';
import { UsuarioService } from '../../../services/usuario.service';

@Component({
    selector: 'app-novo-usuario',
    templateUrl: './novo-usuario.component.html',
    styleUrls: ['./novo-usuario.component.css']
})
export class NovoUsuarioComponent implements OnInit {

    usuario = new UsuarioModel();

    constructor(private usuarioService: UsuarioService,
        private alertService: AlertService,
        private autenticacaoService: AutenticacaoService,
        private route: Router) { }

    ngOnInit(): void {
        
    }


    salvar() {
        this.usuarioService.Inserir(this.usuario).subscribe(sub => {
            this.alertService.sucesso(`Usuário ${this.usuario.nome} registrado com sucesso!`);
            this.autenticar(sub as UsuarioModel);
        })
    }

    autenticar(usuario: UsuarioModel) {

        let autenticacao: AutenticacaoModel = {
            email: usuario.email,
            senha: usuario.senha,
            nome: '',
            token: '',
            id: ''
        }

        this.autenticacaoService.Autenticar(autenticacao).subscribe(sub => {
            localStorage.setItem('usuario', sub.nome);
            localStorage.setItem('token', sub.token);
            this.autenticacaoService.usuarioLogadoEmmiter.emit(true);
            this.alertService.sucesso(`Bem vindo ${sub.nome}`)
            this.route.navigate(['amigos']);
        })
    }
}
