   M S B A M L   `   `   `  ���� R  NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   TextBlockStyle  �� 
TargetType �� Property �� Value  TreeViewItemFocusVisual  ExpandCollapseToggleStyle �� 
TargetType J� SnapsToDevicePixels �� EndPoint �� 
StartPoint � Color � Offset	 ��Name	
 �� X1	 �� Y1	 �� X2	 �� Y2 �� Triggers P� Property P� Value �� 
TargetName  TreeViewItemStyle �� Mode �� RelativeSource �� AncestorType � ColumnDefinitions � RowDefinitions d�Name �� 	ClickMode d� 	IsChecked ��Name �� Padding ��Name ��Name ]� 
Conditions �� Property  �� Value! �� Triggers  EmployeeDateTemplate" �� Orientation  DepartmentTemplate# �� ItemTemplate$ �� ItemsSource�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     :x,http://schemas.microsoft.com/winfx/2006/xaml      %	  &	        &	 �     &	 �     &	 �    7  7  &	 d    &	 �    7  �� "  ��.���  � �� �#000��  � ��$ Verdana)���  � ��$
 Bold"���  � ��$ 14(���  � ��$ Center=���  � ��$ Center=��� .���  � �� �� .R��� �� "  d�.���  � |� .  ��  � ��$ 17����  � ��$ 17����  � �� �� " d�.R��� $��17��$��17��
������ ._��� $��17��$��17�� . #��� ��#��� ��$��1q�._�� .+��� ���� $	 0,1&�$	 0,0&�.��� $ #7FD4FF��$ 0Q�� $ #00AAFF��$ 1Q��� $	 	ExpandImg�����#112844$��1��$
 8��$ 2��$ 8��$ 14���� ���#112844$��1��$
 2��$ 8��$ 14��$ 8�� P�  �@d�	IsChecked$
 TrueY�. ��� $ 	ExpandImg�� � y�$ 	Collapsed=��� "  Q�.���  �@Q�
IsExpanded �� *
IsExpanded+$ TwoWay=���  � ��
 ���� ��  � �� �� *HorizontalContentAlignment+ �� " ����  � �� �� *VerticalContentAlignment+ �� " ����  � ��$ 1,0,0,0q���  � ��# � ����  �@�FocusVisualStyle8   ��  � �� �� " Q�.R��  �� $��19��$
��Auto ��� $
��Auto ��� $��* � �� $
��Auto ��� .+�d� $ Expander��$ Press=�8��  �� *
IsExpanded+ �� *TemplatedParent+�� $ Bd��#��z��#��z��#��z��$��1��# z�� . ._��� $ PART_Header��$��Header��#��z��#��z��# z �� $ 	ItemsHost��$��2��$��1��$��1�� P�  �@Q�
IsExpanded .  . ��� $ 	ItemsHost�� � y�$ 	Collapsed=�P�  �@��HasItems .  . ��� $ Expander�� � y�$ Hidden=�P�  �@Q�
IsSelected . . ��� $ Bd��# � �� � ���� # � �� � ��]�  ��  �@Q�
IsSelected  . ��  �@Q�IsSelectionActive  .  ./��� $ Bd��# � �� � ���� # � �� � ��P�  � {� .  . ��� # � �� � ��! P�  �@%�IsVirtualizing . . ���  � �� �� .R�$� �� .R��� $" 
Horizontal=�.+��� |�.  $��Center=�$��5q� �� *	IsChecked+$ TwoWay=��� $��Center=�$��5q����� *EmployeeName+�� 8#   $ �� *EmployeeCollection+.R��� $" 
Horizontal=�.+��� |�.  $��5q�$��Center=� �� *	IsChecked+$ TwoWay=��� $��	5 5 10 10q����� *DepartmentName+