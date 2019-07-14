import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead-subtitle',
  templateUrl: './td-dashhead-subtitle.component.html',
  styleUrls: ['./td-dashhead-subtitle.component.scss']
})
export class TdDashheadSubtitleComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  get classNames(): string {
    return ['dashhead-subtitle', this.class].join(' ');
  }
}
