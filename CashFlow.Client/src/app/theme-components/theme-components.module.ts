import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TdButtonComponent } from './td-button/td-button.component';
import { TdIconComponent } from './td-icon/td-icon.component';
import { TdDashheadComponent } from './td-dashhead/td-dashhead.component';
import { TdDashheadSubtitleComponent } from './td-dashhead/td-dashhead-subtitle/td-dashhead-subtitle.component';
import { TdDashheadTitleComponent } from './td-dashhead/td-dashhead-title/td-dashhead-title.component';
import { TdDashheadTitlesComponent } from './td-dashhead/td-dashhead-titles/td-dashhead-titles.component';
import { TdDashheadToolbarComponent } from './td-dashhead/td-dashhead-toolbar/td-dashhead-toolbar.component';
import { TdDashheadToolbarItemComponent } from './td-dashhead/td-dashhead-toolbar-item/td-dashhead-toolbar-item.component';
import { TdDashheadToolbarDividerComponent } from './td-dashhead/td-dashhead-toolbar-divider/td-dashhead-toolbar-divider.component';

@NgModule({
  imports: [CommonModule],
  declarations: [
    TdButtonComponent,
    TdIconComponent,
    TdDashheadComponent,
    TdDashheadSubtitleComponent,
    TdDashheadTitleComponent,
    TdDashheadTitlesComponent,
    TdDashheadToolbarComponent,
    TdDashheadToolbarItemComponent,
    TdDashheadToolbarDividerComponent
  ],
  exports: [
    TdButtonComponent,
    TdIconComponent,
    TdDashheadComponent,
    TdDashheadSubtitleComponent,
    TdDashheadTitleComponent,
    TdDashheadTitlesComponent,
    TdDashheadToolbarComponent,
    TdDashheadToolbarItemComponent,
    TdDashheadToolbarDividerComponent
  ]
})
export class ThemeComponentsModule {}
