/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TdIconComponent } from './td-icon.component';

describe('TdIconComponent', () => {
  let component: TdIconComponent;
  let fixture: ComponentFixture<TdIconComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TdIconComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TdIconComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
