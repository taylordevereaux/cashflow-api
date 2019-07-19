import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-dashhead-titles',
  templateUrl: './td-dashhead-titles.component.html',
  styleUrls: ['./td-dashhead-titles.component.scss']
})
export class TdDashheadTitlesComponent implements OnInit {
  @Input() class = '';
  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['dashhead-titles', this.class].join(' ');
  }
}
