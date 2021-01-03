import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertService } from '../../services/alert.service';
import { AutenticacaoService } from '../../services/autenticacao.service';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

    usuario: string;

    constructor(private autenticacaoService: AutenticacaoService,
        private route: Router,
        private alertService: AlertService) { }

    ngOnInit(): void {
        this.usuario = this.autenticacaoService.UsuarioAutenticado();
    }

    Sair() {
        this.autenticacaoService.Sair();
        this.alertService.info("Até a proxima!")
        this.route.navigate(['/'])
    }

}
