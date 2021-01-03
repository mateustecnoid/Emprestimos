import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AmigosNovoComponent } from './amigos-novo.component';

describe('AmigosNovoComponent', () => {
  let component: AmigosNovoComponent;
  let fixture: ComponentFixture<AmigosNovoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AmigosNovoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AmigosNovoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
