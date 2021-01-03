import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AmigoModel } from '../../../models/amigo.model';
import { AlertService } from '../../../services/alert.service';
import { AmigoService } from '../../../services/amigo.service';

@Component({
    selector: 'app-amigos-atualizar',
    templateUrl: './amigos-atualizar.component.html',
    styleUrls: ['./amigos-atualizar.component.css']
})
export class AmigosAtualizarComponent implements OnInit {
    form: FormGroup;
    amigo: AmigoModel;
    id: number;

    constructor(private router: Router,
        private route: ActivatedRoute,
        private formBuilder: FormBuilder,
        private amigoService: AmigoService,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.route.params.subscribe(data => {
            this.id = data["id"];
            this.amigoService.obterPorId(data["id"]).subscribe(sub => {
                this.amigo = sub;
                this.inicializarFormulario();
            })
        });
    }

    inicializarFormulario() {
        this.form = this.formBuilder.group({
            apelido: [this.amigo.apelido, Validators.required],
            telefone: [this.amigo.telefone, Validators.required],
        });
    }

    salvar() {
        this.amigo = this.form.value;
        this.amigoService.atualizar(this.id, this.amigo).subscribe(sub => {
            this.router.navigate(['amigos']);
            this.alertService.sucesso(`Amigo ${this.amigo.apelido} foi atualizado.`)
        })
    }

}
