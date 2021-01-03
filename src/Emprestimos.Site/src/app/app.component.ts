import { Component } from '@angular/core';
import { AutenticacaoService } from './services/autenticacao.service';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})
export class AppComponent {
    title = 'emprestimos';

    /**
     *
     */
    constructor(public autenticacaoService: AutenticacaoService) {
    }
}
