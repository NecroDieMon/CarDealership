   M S B A M L   `   `   `  ���� H  DCarDealership, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:CarDealershipCarDealership  /    )CarDealership.ConfigurationAssemblyWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -localclr-namespace:CarDealership     _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes    � Title$<  6Окно комплектации автомобиля��$	��466��$	��840��.��� ���	#ffdadada$	��466��$	��840�� � RowDefinitions �� $	��64* ��� $	��11* � � ColumnDefinitions �� $	��47* ��� $
��129* ��� $
��129* ��� $
��129* ��� $	��40* �.+��� 
������� �� CornerRadius$ 20��$��1��$��0��$��3��$��2�� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     
BlurRadius$ 30Q�   Color$ 	LightGray��   ShadowDepth$ 6Q�&   System.Windows.Controls.DataGrid  -     Name$ SpoilersGrid��$��1��$��0��$��2��	   AutoGenerateColumns	 .  
   
IsReadOnly
 .    Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ Спойлер��1  +System.Windows.Controls.DataGridBoundColumn   Binding ��  �� Path$ NameSpoiler�  $ Цена�� �� $ PriceSpoiler�  -   $ 
ColorsGrid��$��2��$��0��$��2��	 .  
 .    $# Цвет автомобиля�� �� $ 	NameColor�  $ Цена�� �� $ 
PriceColor�  -   $ EnginesGrid��$��3��$��0��$��2��	 .  
 .    $ Двигатель�� �� $ NameEngines�  $ Цена�� �� $ PriceEngine�