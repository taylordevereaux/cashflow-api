/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { TdDashheadToolbarItemComponent } from './td-dashhead-toolbar-item.component';

describe('TdDashheadToolbarItemComponent', () => {
  let component: TdDashheadToolbarItemComponent;
  let fixture: ComponentFixture<TdDashheadToolbarItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TdDashheadToolbarItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TdDashheadToolbarItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
