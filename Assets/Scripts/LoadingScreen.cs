using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    public int startCountText = 5;
    public float timeBetweenTexts = 0.1f;
    public GameObject closeWindow;
    public GameObject loadingWindows;
    public GameObject loadingText;
    public Scrollbar scrollRect;
    public AudioSource workWindowsMusic;

    private readonly string[] _text = {
        "Initializing cgroup subsys cpuset",
        "Initializing cgroup subsys cpu.",
        "Initializing cgroup subsys cpuacct",
        "os version 4.10.0-31-generic (buildd@lgw01-16)",
        "86/fpu: xstate_offset [2]: 576, xstate_sizes[2]: 256",
        "86/fpu: Supporting XSAVE feature 0x01: 'x87 floating point registers'",
        "86/fpu: Supporting XSAVE feature 0x02: 'SSE registers'",
        "86/fpu: Supporting XSAVE feature 0x04: 'AVX registers'",
        "86/fpu: Enabled xstate features 8x7, context size is 832 bytes, using 'standard' format.",
        "86/fpu: Using 'lazy' FPU context switches.",
        "820: BIOS-provided physical RAM map:",
        "IOS-e820: [mem 8x0000000000000000-0x0000eeeeeee9fbff]",
        "IOS-e820: [mem 8x000000000009fcee-exeeeeeeeeeee9ffff]",
        "IOS-e820: [mem 0x00000000000f0000-0x00000000",
        "IOS-e820: [mem 0x0000000000100000-0x000000007",
        "IOS-e820: [mem 0x000000007fff0000-0x00000000",
        "IOS-e820: [mem 0x00000000fffc0000-0x000000001",
        "X (Execute Disable) protection: active",
        "MBIOS 2.5 present.",
        "MI: innotek GmbH virtualkos/virtualkos, BIOS virtualkos 12/01/2006",
        "ypervisor detected: KVM",
        "820: update [mem 6x00000000-exc0000fff] usable ==> reserved",
        "820: remove [mem 0x0000000-0x000fffff] usable",
        "820: last_pfn 0x7fffe max_arch_pfn=0x400000000",
        "TRR default type: uncachable",
        "TRR variable ranges disabled:",
        "86/PAT: Configuration [0-7]: WB WC UC- UC WB WC UC- WT",
        "TRR: Disabled",
        "  ()",
        "  ||  ",
        "  ||  ",
        "()||()",
        "usable",
        "reserved",
        "reserved",
        "usable",
        "ACPI data",
        "reserved",
        "PU MTRRS all blank virtualized system.",
        "ound SMP MP-table at [mem 0x0009fffe-ex0009ffff] mapped at [ffff88000009fff0]",
        "canning 1 areas for low memory corruption",
        "ase memory trampoline at [ffff880000099000] 99000 size 24576",
        "RK [0x02200000, 0x02200fff) PGTABLE",
        "RK [0x02201000, 0x02201fff] PGTABLE",
        "RK [0x02202000, 0x82202fff] PGTABLE",
        "RK [0x02203000, 0x02203fff] PGTABLE",
        "RK [0x02204000, ex82204fff) PGTABLE",
        "ANDISK: [men 8x33b68000-8x35dabfff]",
        "CPI: Early table checksum verification disabled",
        "CPI: RSDP 0x000000000000000 000024 (ve2 VBOX )",
        "CPI: XSDT 6x000000007FFF0836 60003C (với VBOX",
        "CPI: FACP 0x000000007FFF00F0 0000F4 (v04 VBOX",
        "CPIS DSDT 0X000000007FFFD470 002118 (với VBOX",
        "CPI: FACS 8x000000007FFF8200 000040",
        "Мать в норме",
        "VBOXXSDT 00000001 ASL 00000061)",
        "VBOXFACP 00000001 ASL 00000061)",
        "VBOXBIOS 00000002 INTL 20100528)",
    };
    
    private void Start()
    {
        StartCoroutine(LoadingCourotine());
    }

    private IEnumerator LoadingCourotine()
    {
        for (int i = 0; i <= startCountText; i++)
        {
            var text = Instantiate(loadingText, loadingWindows.transform).GetComponent<Text>();
            text.text = _text[i];
        }
        for (int i = startCountText+1; i < _text.Length; i++)
        {
            yield return new WaitForSeconds(timeBetweenTexts);
            var text = Instantiate(loadingText, loadingWindows.transform).GetComponent<Text>();
            text.text = _text[i];
            scrollRect.value = 0;
        }
        yield return new WaitForSeconds(3f);
        closeWindow.SetActive(false);
        workWindowsMusic.Play();
        StartCoroutine(SystemController.Instance.OnSystemStart());
    }
}