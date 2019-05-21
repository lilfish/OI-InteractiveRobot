# Installation Guides  Intel OpenVINO on AAEON UP squared Board with Intel Myriad


## Installing Linux On AAEON UP squared:

Ubuntu versions currently validated on UP series:

Ubuntu 16.04 LTS (Kernel 4.15) for Intel OpenVINO with intel Myriad support


## Ubuntu Installation with Kernel 4.15.0:


- [ ] Download Ubuntu 16.04.5 ISO (works with desktop and server edition)

        http://old-releases.ubuntu.com/releases/16.04.5/
        Download from this link the "ubuntu-16.04.5-desktop-amd64.iso"

- [ ] Burn the downloaded image on a USB stick (You can use http://etcher.io)
- [ ] While installing **DO NOT** select option "automatic updates"
- [ ] After the reboot you need to add AAEON repository:
    ```nginx 
        sudo add-apt-repository ppa:ubilinux/up
     ```
- [ ] Update the repository list
    ```nginx 
        sudo apt update
    ```
- [ ] Remove all the generic installed kernel  **READ CAREFUL!**
    ```nginx 
        sudo apt-get autoremove --purge 'linux-.*generic'
    ```
- [ ] Install AAEON upboard kernel:
    ```nginx 
        sudo apt-get install linux-image-generic-hwe-16.04-upboard
    ```
- [ ] Install the updates (please make sure to not upgrade the system to Ubuntu 18.04):
    ```nginx 
        sudo apt dist-upgrade -y
        sudo reboot
    ```
- [ ] After the reboot you can verify that the kernel is indeed installed by typing
    ```nginx 
        uname -a
            You should find the upboard04 or higher package 
            Linux upsquared-UP-Ryan 4.15.0-37-generic #40~upboard04-Ubuntu
    ```


## Install the Intel Distribution of OpenVINO Toolkit
Download the Intel Distribution of OpenVINO toolkit package file from Intel Distribution of OpenVINO toolkit for Linux.

https://software.intel.com/en-us/openvino-toolkit/choose-download/free-download-linux

- [ ] Unpack the .tgz file:
    ```nginx 
        tar -xvzf l_openvino_toolkit_p_<version>.tgz
    ```
- [ ] Go to the l_openvino_toolkit_p_<version> directory:
    ```nginx 
        cd l_openvino_toolkit_p_<version>
    ```
- [ ] start the GUI Installation Wizard:
    ```nginx 
        sudo ./install_GUI.sh
    ```
- [ ] When Installing continue to options and pick Cutomize. here you add the Moviduis VPU capabilities if not already selected.
    ![installation_1](https://docs.openvinotoolkit.org/latest/openvino-install-linux-02.png)

- [ ] A Complete screen indicates that the core components have been installed:
    ![installation_2](https://docs.openvinotoolkit.org/latest/openvino-install-linux-03.png)
  
  
## Install OpenVINO External Software Dependencies