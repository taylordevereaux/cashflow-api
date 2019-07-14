import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead',
  templateUrl: './td-dashhead.component.html',
  styleUrls: ['./td-dashhead.component.scss']
})
export class TdDashheadComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['dashhead', this.class].join(' ');
  }
}
