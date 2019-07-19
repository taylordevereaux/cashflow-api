import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead-toolbar-item',
  templateUrl: './td-dashhead-toolbar-item.component.html',
  styleUrls: ['./td-dashhead-toolbar-item.component.scss']
})
export class TdDashheadToolbarItemComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['dashhead-toolbar-item', this.class].join(' ');
  }
}
