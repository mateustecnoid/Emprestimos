import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AmigoModel } from '../../../models/amigo.model';
import { AlertService } from '../../../services/alert.service';
import { AmigoService } from '../../../services/amigo.service';

@Component({
    selector: 'app-amigos-novo',
    templateUrl: './amigos-novo.component.html',
    styleUrls: ['./amigos-novo.component.css']
})
export class AmigosNovoComponent implements OnInit {

    form: FormGroup;
    amigo: AmigoModel = {
        id: null,
        apelido: '',
        telefone: '',
        quantidadeDeJogosEmprestados: null
    }

    constructor(private amigosService: AmigoService,
        private router: Router,
        private formBuilder: FormBuilder,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.inicializarFormulario();
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            apelido: ['', Validators.required],
            telefone: ['', Validators.required],
        });
    }

    salvar() {
        this.amigo = this.form.value;
        this.amigosService.inserir(this.amigo).subscribe(sub => {
            this.router.navigate(['amigos']);
            this.alertService.sucesso(`Amigo ${this.amigo.apelido} foi registrado.`)
        })
    }

}
