import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JogosAtualizarComponent } from './jogos-atualizar.component';

describe('JogosAtualizarComponent', () => {
  let component: JogosAtualizarComponent;
  let fixture: ComponentFixture<JogosAtualizarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JogosAtualizarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JogosAtualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
