   M S B A M L   `   `   `  ����?  ;Rich, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Rich.View	Rich.View  5      /clr-namespace:Rich.ViewModelRich.ViewModel  5          Rich.View.PropertyPane   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Rich.View     5      +vmclr-namespace:Rich.ViewModel     5      .��5      � 
�������  � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   �� $��0��6   $��
Properties��6   �� 5   
   -   5         ��Name$ PropertiesPanel��5       $��1��6   ��69   ��  �� Path$ 
Properties� � 	Resources 5       �� DataType%   Rich.ViewModel.NamePropertyItem"   Rich.View.NamePropertyEditor � DataContext��%U   (��       5      *, +)�� 6   "  6   .R�5         6/   �� 5      5       �� 
GroupStyle 5      (  "System.Windows.Controls.GroupStyle  5         ContainerStyle 5      �� 5       �� 
TargetType" ��6    .�5      �� 	 �� Property	 � ��
 �� Value
 5   "   �� 5   &   .R�5   *   9�  9� 
IsExpanded . ��5   .   �� 5    2   ��68   �� $
 Name�.��5"   .   �� 5#   +   5$   '   5&      5'      5)      5+      5,      5-      