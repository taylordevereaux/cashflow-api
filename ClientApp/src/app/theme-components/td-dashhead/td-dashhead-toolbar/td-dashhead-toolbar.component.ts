import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead-toolbar',
  templateUrl: './td-dashhead-toolbar.component.html',
  styleUrls: ['./td-dashhead-toolbar.component.scss']
})
export class TdDashheadToolbarComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['dashhead-toolbar', this.class].join(' ');
  }
}
