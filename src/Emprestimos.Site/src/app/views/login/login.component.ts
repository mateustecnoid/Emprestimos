import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AutenticacaoModel } from '../../models/autenticacao.model';
import { AlertService } from '../../services/alert.service';
import { AutenticacaoService } from '../../services/autenticacao.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    form: FormGroup;
    autenticacao: AutenticacaoModel = {
        email: '',
        senha: '',
        nome: '',
        token: '',
        id: ''
    }

    constructor(private autenticacaoService: AutenticacaoService,
        private route: Router,
        private formBuilder: FormBuilder,
        private alertService: AlertService) { }

    ngOnInit(): void {

        const usuarioLogado = localStorage.getItem("token");

        if (usuarioLogado)
            this.route.navigate(['amigos']);


        this.inicializarFormulario();
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            email: ['', Validators.required],
            senha: ['', Validators.required],
        });
    }

    logar() {
        if (this.form.valid) {
            this.autenticacao = this.form.value;
            this.autenticacaoService.Autenticar(this.autenticacao).subscribe(sub => {
                localStorage.setItem('usuario', sub.nome);
                localStorage.setItem('token', sub.token);
                this.autenticacaoService.usuarioLogadoEmmiter.emit(true);
                this.alertService.sucesso(`Bem vindo ${sub.nome}`)
                this.route.navigate(['amigos']);
            });
        }
        else {
            this.alertService.aviso("Formulario de autenticação preenchido de forma incorreta!")
        }
    }

}
