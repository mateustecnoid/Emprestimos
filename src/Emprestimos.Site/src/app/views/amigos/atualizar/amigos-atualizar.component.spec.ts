import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmigosAtualizarComponent } from './amigos-atualizar.component';

describe('AmigosAtualizarComponent', () => {
  let component: AmigosAtualizarComponent;
  let fixture: ComponentFixture<AmigosAtualizarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmigosAtualizarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmigosAtualizarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
