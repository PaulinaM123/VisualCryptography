   M S B A M L   `   `   `  ����P  LKryptografia_wizualna, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Kryptografia_wizualnaKryptografia_wizualna  5      -    'Kryptografia_wizualna.Zasada_działania   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:Kryptografia_wizualna     5      $	��590��5      $	��720��6   .��5	      � .+�5
   
   �� $
��Left=�6   $	��220��6+   $��
32,158,0,0q�68   $	��Top=�6L   $	��316��6d   $��
tabela.PNG��6p   �� 5   
   $����Źródło:  "Ochrona danych i zabezpieczenia w systemach teleinformatycznych", pod red. Janusza Stokłosy, Wyd. 2 popr. , Poznań, 
				Wydawnictwo Politechniki Poznańskiej, 2005, ISBN 83-7143-478-2.��6   $
��Left=�6   $��64,519,-116,0q�6  $	��Top=�62  $	��772��6J  $��36��6V  $��10(�6b  $��Normal"�6p  �� 5   
   $
��Left=�6   $��4,-9,0,0q�6/   $
��Wrap=�6A   $	��Top=�6U   $	��149��6m   $	��711��6z   ���	#FF0D50DE$��14(�6�   �� 6�   $� ��6�   �� 6�   �� 6�   $�	��6�   �� 6�   $H�BW obu algorytmach (ProstyPrzykład oraz KorekcjaZniekształceń) p��6�   �� 6&  $���ojedynczy obraz dzielony jest na dwa obrazy zwane udziałami. Po nałożeniu na siebie dwóch udziałów, uzyskujemy rozszyfrowany obraz.��6*  �� 6�  $P�J Żaden z udziałów nie zdradza żadnej informacji z oryginalnego obrazu.��6�  �� 6  �� 6  $���	W najprostszym przypadku kodowany jest obraz czarno-biały. Każdy piksel takiego obrazu dzielony jest na dwa piksele. Jeśli dzielony piksel jest biały, to powstałe piksele (jeden czarny i jeden biały) mają takie same ułożenie na dwóch udziałach. Natomiast jeżeli piksel jest czarny, to powstałe piksele mają odwrotne ułożenie na dwóch udziałach. ��6  6�  �� 5   
   $
��Left=�6   $��12,396,-4,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $	��148��6p   $	��712��6}   ���	#FF0D50DE$��14(�6�   �� 6�   �� 6�   $�	��6�   �� 6�   $�W ��6�   �� 6�   $�algorytmie KorekcjaZnieks��6�   �� 6  $�	ztałceń��6	  �� 6  $� ��6  �� 6)  $�	również��6-  �� 6>  $X�R kodowany jest obraz czarno-biały. Każdy piksel takiego obrazu dzielony jest na ��6B  �� 6�  $�cztery��6�  �� 6�  $� piksele��6�  �� 6�  $� tworzące kwadrat��6�  �� 6�  $�. ��6�  �� 6�  $p�jDla każdego z dwóch kolorów pikseli jest 6 możliwości koloorowania subpikseli, które wybierane są l��6�  �� 6f  $���osowa. W przypadku bialego piksela wartości poszczególnych subpikseli są takie same w obu udziałach, natomiast w czarnym wartości subpikseli są odwrotne. ��6j  �� 6  $B�<Zastosowanie takiego algorytmu minimalizuje znikształcenia.��6  6X  �� 5   
   $
��Left=�6   $	��194��6+   $��360,160,0,0q�68   $	��Top=�6M   $	��296��6e   $��
cztery.PNG��6q   �� 5   
   $
��Left=�6   $��358,354,0,0q�6/   $
��Wrap=�6D   $	��Top=�6X   $��44��6p   $	��258��6|   ���	#FF0D50DE$��14(�6�   �� 6�   $1�+Przykład podziału piksela na 4 subpiksele��6�   �� 6�   $� (1 z 6 możliwości)��6�   6  �� 5   
   $
��Left=�6   $��
36,360,0,0q�6/   $
��Wrap=�6C   $	��Top=�6W   $��40��6o   $	��272��6{   ���	#FF0D50DE$��14(�6�   �� 6�   $%�Przykład podziału piksela na ��6�   �� 6�   $�2��6�   �� 6�   $� subpiksele��6�   �� 6   $� (wszystkei możliwości)��6  6&  5      5      