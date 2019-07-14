import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead-title',
  templateUrl: './td-dashhead-title.component.html',
  styleUrls: ['./td-dashhead-title.component.scss']
})
export class TdDashheadTitleComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  get classNames(): string {
    return ['dashhead-title', this.class].join(' ');
  }
}
