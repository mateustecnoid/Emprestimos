import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmprestimosNovoComponent } from './emprestimos-novo.component';

describe('EmprestimosNovoComponent', () => {
  let component: EmprestimosNovoComponent;
  let fixture: ComponentFixture<EmprestimosNovoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EmprestimosNovoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmprestimosNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
