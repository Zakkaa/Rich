   M S B A M L   `   `   `  ����?  ;Rich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Rich.View	Rich.View  5      /clr-namespace:Rich.ViewModelRich.ViewModel  5          Rich.View.MainPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Rich.View     5      +vmclr-namespace:Rich.ViewModel     5      -   5        .��5      � 
�������  � ColumnDefinitions  5   
   �� 5      $	��20* �6   �� 5      $��3 �6   �� 5      $	��50* �6   �� 5      $��3 �6   �� 5      $	��30* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
      Rich.View.ProfilePane  $��0��6   $��0��6)   $��5��69      Rich.View.NavigationPane  5   
   $��1��6   $��0��6-    � DataContext 6>   ��  �� Path$ 
Navigation��� 5   
   $��1��6   $��1��6$   $��3��5      $��Stretch=�6!    �� ShowsPreview . 5         Rich.View.ContentPane  5   
   $��1��6   $��2��6)    69   �� $ Content��� 5   
   $��1��6   $��3��6$   $��3��5      $��Stretch=�6!    . 5          Rich.View.PropertyPane  5!   
   $��1��6   $��4��6*    6:   �� $ 
Properties��� 5"   
   -   5        $��4��5"      $��应用��6!   $
��Left=�6.   $��119,372,0,0q�6I   $��1��6^   $	��Top=�6k   $��24��6�   $��74��6�   5#      5$      