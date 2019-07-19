import { Component, OnInit, Input, HostBinding } from '@angular/core';

@Component({
  selector: 'td-icon',
  templateUrl: './td-icon.component.html',
  styleUrls: ['./td-icon.component.scss']
})
export class TdIconComponent implements OnInit {
  @Input() icon: string;

  constructor() {}

  ngOnInit() {}

  @HostBinding('class')
  get hostClasses(): string {
    return ['icon', `icon-${this.icon}`].join(' ');
  }
}
