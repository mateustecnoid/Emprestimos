import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JogosNovoComponent } from './jogos-novo.component';

describe('JogosNovoComponent', () => {
  let component: JogosNovoComponent;
  let fixture: ComponentFixture<JogosNovoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JogosNovoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JogosNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
