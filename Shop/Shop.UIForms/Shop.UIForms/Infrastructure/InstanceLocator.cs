﻿
namespace Shop.UIForms.Infrastructure
{
    using viewModel;
    public  class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }

    }
}
