# HFU_APE_app
HFU Appentwicklung


```
<CollectionView Grid.Row="2" Grid.ColumnSpan="2">
    <CollectionView.ItemsSource>
        <x:Array Type="{x:Type x:String}">
            <x:String>Apples</x:String>
            <x:String>Bananas</x:String>
            <x:String>Oranges</x:String>
        </x:Array>
    </CollectionView.ItemsSource>

    <CollectionView.ItemTemplate>
        <DataTemplate>
            <SwipeView>
                <SwipeView.RightItems>
                    <SwipeItems>
                        <SwipeItem Text="Delete"
                                   BackgroundColor="Red" />
                    </SwipeItems>
                </SwipeView.RightItems>
                <Grid Padding="0,5">
                    <Border Padding="10">
                        <Border.StrokeShape>
                            <RoundRectangle CornerRadius="10" />
                        </Border.StrokeShape>
                        <Label Text="{Binding .}" FontSize="24" />
                    </Border>
                </Grid>
            </SwipeView>
        </DataTemplate>
    </CollectionView.ItemTemplate>
</CollectionView>

```