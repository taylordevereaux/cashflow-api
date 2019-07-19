import { Component, OnInit, HostBinding, Input } from '@angular/core';

@Component({
  selector: 'td-dashhead-toolbar-divider',
  templateUrl: './td-dashhead-toolbar-divider.component.html',
  styleUrls: ['./td-dashhead-toolbar-divider.component.scss']
})
export class TdDashheadToolbarDividerComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['dashhead-toolbar-divider hidden-xs', this.class].join(' ');
  }
}
